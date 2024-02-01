- Create Model
- Create Interface + Mockup data file in data folder
- Create Controller
- Add data dependency in Program.cs file

For Database:
- Install Entity Framework + Entity Framework SqlServer + Entity Design + from tool NuGet Package Manager
- Install/Run this command: "dotnet tool install --global dotnet-ef" 
- Create Context file in Data Folder
- Add connection string in appsettings.json file
	"ConnectionStrings": {
		"DefaultConnection": "Server=localhost;Database=HMS;Integrated Security=true;Encrypt=false;"
	},
- Add this code in Program.cs
	builder.Services.AddDbContext<CommanderContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));
- Run command to generate migration files:
	dotnet ef migrations add InitialMigration
        dotnet ef database update


For DTO:
- Install Automapper dependency injection package
- Add this line of code in program.cs
	builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())


For JWT Authorization:
- Install JWT package
- Add these lines in program.cs
  builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

   app.UseAuthentication();
- Add these lines in appsettings.json
  "Jwt": {
  "Issuer": "http://localhost:7086/",
  "Audience": "http://localhost:7086/",
  "Key": "ABSC231321sknda@jnfdnsfdh@@_!@@#dsadaxa"
},


