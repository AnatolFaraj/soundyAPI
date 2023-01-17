using Microsoft.AspNetCore.Builder;


namespace WebAPI.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static void UseSwaggerStartPage(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
