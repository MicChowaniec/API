using bookingdesks.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder

        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000", "http://appname.azurestaticapps.net");
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Booking desk API",
        Version = "v1"
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "booking desk";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Endpoint");
    swaggerUIOptions.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-rooms", async () => await RoomsRepository.GetRoomsAsync()).WithTags("Rooms Endpoints");

app.MapGet("/get-rooms-by-id/{roomId}", async (int roomId) =>
{
    Room roomToReturn = await RoomsRepository.GetRoomByIdAsync(roomId);

    if (roomToReturn != null)
    {
        return Results.Ok(roomToReturn);
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Rooms Endpoints");

app.MapPost("/create-room", async (Room roomToCreate) =>
{
    bool createSuccessful = await RoomsRepository.CreateRoomAsync(roomToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create succesful.");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Rooms Endpoints");

app.MapPut("/update-room", async (Room roomToUpdate) =>
{
    bool updateSuccessful = await RoomsRepository.UpdateRoomAsync(roomToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Create succesful.");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Rooms Endpoints");

app.MapDelete("/delete-room-by-id/{roomId}", async (int roomId) =>
{
    bool deleteSuccessful = await RoomsRepository.DeleteRoomAsync(roomId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete succesful.");
    }
    else
    {
        return Results.BadRequest();
    }

}).WithTags("Rooms Endpoints");

app.Run();