using IES_ADMIN_ACADEM_API.Entities;


    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //Prevent model classes object received by endpoints to throw 'the field is required'
    // but don't forget that this supresses all required annotations for all memberrs. 
    builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
    builder.Services.AddControllersWithViews().AddNewtonsoftJson();
    builder.Services.AddEndpointsApiExplorer(); //UNCOMMENT FOR SWAGGER
    builder.Services.AddSwaggerGen(); //UNCOMMENT FOR SWAGGER


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(); //UNCOMMENT FOR SWAGGER
        app.UseSwaggerUI(); //UNCOMMENT FOR SWAGGER
    }

//app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


