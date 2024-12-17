namespace Fina.api.Common.Api
{
    public static class AppExtension
    {
        public static void ConfigureDevEnviroment(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            //app.MapSwagger().RequireAuthorization();

        }
    }
}
