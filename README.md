# aspnetcoresk-vue
A simple starter kit for asp.net core project using VueJS as client framework and IdentityServer4 for authentication.

## Requirements
- ASP.NET Core 2.1
- NodeJS 10.8.0

## Projects
- **AspNetCoreSk.IdentityServer** is the IdentityServer4 asp.net core project
- **AspNetCoreSk.Vue** is the asp.net core client project
- **AspNetCoreSk.Vue.Endpoint** is a simple Razor class library which contains an authorized webapi. It's referenced by the AspNetCoreSk.Vue project.

## Getting started
- Run EntityFrameworkCore **update-database** for the **AspNetCoreSk.IdentityServer** project.
- Run **npm install** for the **AspNetCoreSk.Vue** project to install all the npm dependencies.
- Run **webpack** to create the client's bundles.
- Be sure to run both **AspNetCoreSk.IdentityServer** and **AspNetCoreSk.Vue** projects.

## Flow
The client application will run on the https://localhost:44388/ address.<br/>
You will be redirected to the IdentityServer login page. Here you could login or register a new user (if it's the first time you run the application).<br/>
After authentication you will be redirected to client app and you should see a list of 3 items in home page.

## References
- **IdentityServer4** [https://identityserver4.readthedocs.io/en/release/](https://identityserver4.readthedocs.io/en/release/)
- **Using IdentityServer4 with ASP.NET Identity** [https://identityserver4.readthedocs.io/en/release/quickstarts/6_aspnet_identity.html](https://identityserver4.readthedocs.io/en/release/quickstarts/6_aspnet_identity.html)
- **Add IdentityServer4 Javascript client** [https://identityserver4.readthedocs.io/en/release/quickstarts/7_javascript_client.html](https://identityserver4.readthedocs.io/en/release/quickstarts/7_javascript_client.html)
- **VueJS official docs** [https://vuejs.org/v2/guide/](https://vuejs.org/v2/guide/)
