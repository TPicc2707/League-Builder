var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

//builder.Services.AddRefitClient<ILeagueService>().ConfigureHttpClient(x =>
//{
//    x.BaseAddress = new Uri("https://localhost:6063");
//});

//builder.Services.AddRefitClient<ITeamService>().ConfigureHttpClient(x =>
//{
//    x.BaseAddress = new Uri("https://localhost:6063");
//});

//builder.Services.AddRefitClient<IPlayerService>().ConfigureHttpClient(x =>
//{
//    x.BaseAddress = new Uri("https://localhost:6063");
//});

builder.Services.AddRefitClient<ILeagueService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://localhost:6063");
    })
    .ConfigurePrimaryHttpMessageHandler(configure =>
    new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        //SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
        //ClientCertificates = { new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\localhost-cert.cer")},
        //ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
        //{
        //    return true;
        //}
    });

builder.Services.AddRefitClient<ITeamService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://localhost:6063");
    })
    .ConfigurePrimaryHttpMessageHandler(configure =>
    new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        //SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
        //ClientCertificates = { new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\localhost-cert.cer")},
        //ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
        //{
        //    return true;
        //}
    });

builder.Services.AddRefitClient<IPlayerService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://localhost:6063");
    })
    .ConfigurePrimaryHttpMessageHandler(configure =>
    new HttpClientHandler()
    {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        //SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
        //ClientCertificates = { new System.Security.Cryptography.X509Certificates.X509Certificate(@"C:\localhost-cert.cer")},
        //ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
        //{
        //    return true;
        //}
    });

await builder.Build().RunAsync();
