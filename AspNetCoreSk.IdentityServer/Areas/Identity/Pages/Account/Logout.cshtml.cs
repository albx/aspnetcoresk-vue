using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AspNetCoreSk.IdentityServer.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IIdentityServerInteractionService _interactionService;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _interactionService = interactionService;
        }

        public class LogoutInputModel
        {
            public string LogoutId { get; set; }

            public bool ShowLogoutPrompt { get; set; }
        }

        public class LoggedOutViewModel
        {
            public string PostLogoutRedirectUri { get; set; }
            public string ClientName { get; set; }
            public string SignOutIframeUrl { get; set; }

            public bool AutomaticRedirectAfterSignOut { get; set; }

            public string LogoutId { get; set; }
            public bool TriggerExternalSignout => ExternalAuthenticationScheme != null;
            public string ExternalAuthenticationScheme { get; set; }
        }

        public async Task<IActionResult> OnGet(string logoutId)
        {
            var model = await BuildLogoutInputModelAsync(logoutId);
            if (!model.ShowLogoutPrompt)
            {
                return await OnPost(model);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(LogoutInputModel model)
        {
            var viewModel = await BuildLoggedOutViewModelAsync(model.LogoutId);
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return Redirect(viewModel.PostLogoutRedirectUri);
        }

        private async Task<LogoutInputModel> BuildLogoutInputModelAsync(string logoutId)
        {
            var inputModel = new LogoutInputModel
            {
                LogoutId = logoutId,
                ShowLogoutPrompt = true
            };

            if (!User.Identity.IsAuthenticated)
            {
                inputModel.ShowLogoutPrompt = false;
                return inputModel;
            }

            var context = await _interactionService.GetLogoutContextAsync(logoutId);
            if (!context.ShowSignoutPrompt)
            {
                inputModel.ShowLogoutPrompt = false;
                return inputModel;
            }

            return inputModel;
        }

        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            var logout = await _interactionService.GetLogoutContextAsync(logoutId);

            var viewModel = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = false,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User.Identity.IsAuthenticated)
            {
                var identityProvider = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (identityProvider != null && identityProvider != IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(identityProvider);
                    if (providerSupportsSignout)
                    {
                        if (viewModel.LogoutId == null)
                        {
                            viewModel.LogoutId = await _interactionService.CreateLogoutContextAsync();
                        }

                        viewModel.ExternalAuthenticationScheme = identityProvider;
                    }
                }
            }
            
            return viewModel;
        }
    }
}