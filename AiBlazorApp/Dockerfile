FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5282

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AiBlazorApp/AiBlazorApp.csproj", "."]
RUN ls -la /src
RUN dotnet restore "AiBlazorApp.csproj"
COPY . .

RUN dotnet build "AiBlazorApp/AiBlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AiBlazorApp/AiBlazorApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AiBlazorApp.dll"]
