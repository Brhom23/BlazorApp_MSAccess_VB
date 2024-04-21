Imports System.Diagnostics.Metrics
Imports BlazorApp_MSAccess_VB.Client.Pages
Imports BlazorApp_MSAccess_VB.Components
Imports BlazorApp_MSAccess_VB.Components.Account
Imports BlazorApp_MSAccess_VB.Data
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Components.Authorization
Imports Microsoft.AspNetCore.Identity
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Public Class Program
    Public Shared Sub Main(ByVal args As String())
        Dim builder = WebApplication.CreateBuilder(args)
        builder.Services.AddRazorComponents().AddInteractiveServerComponents().AddInteractiveWebAssemblyComponents()
        builder.Services.AddCascadingAuthenticationState()
        builder.Services.AddScoped(Of IdentityUserAccessor)()
        builder.Services.AddScoped(Of IdentityRedirectManager)()
        builder.Services.AddScoped(Of AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider)()
        builder.Services.AddAuthentication(Function(options)
                                               options.DefaultScheme = IdentityConstants.ApplicationScheme
                                               options.DefaultSignInScheme = IdentityConstants.ExternalScheme
                                           End Function).AddIdentityCookies()
        Dim connectionString = If(builder.Configuration.GetConnectionString("DefaultConnection_jet"), CSharpImpl.__Throw(Of)(New InvalidOperationException("Connection string 'DefaultConnection_jet' not found.")))
        builder.Services.AddDbContext(Of ApplicationDbContext)(Function(options) options.UseJet(connectionString))
        builder.Services.AddDatabaseDeveloperPageExceptionFilter()
        builder.Services.AddIdentityCore(Of ApplicationUser)(Function(options) CSharpImpl.__Assign(options.SignIn.RequireConfirmedAccount, True)).AddEntityFrameworkStores(Of ApplicationDbContext)().AddSignInManager().AddDefaultTokenProviders()
        builder.Services.AddSingleton(Of IEmailSender(Of ApplicationUser), IdentityNoOpEmailSender)()
        Dim app = builder.Build()

        If app.Environment.IsDevelopment() Then
            app.UseWebAssemblyDebugging()
            app.UseMigrationsEndPoint()
        Else
            app.UseExceptionHandler("/Error")
            app.UseHsts()
        End If

        app.UseHttpsRedirection()
        app.UseStaticFiles()
        app.UseAntiforgery()
        app.MapRazorComponents(Of App)().AddInteractiveServerRenderMode().AddInteractiveWebAssemblyRenderMode().AddAdditionalAssemblies(GetType(Counter).Assembly)
        app.MapAdditionalIdentityEndpoints()
        app.Run()
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function <Obsolete("Please refactor calling code to use normal throw statements")>
            Shared Function __Throw(Of T)(ByVal e As Exception) As T
            Throw e
        End Function
    End Class
End Class
