FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
WORKDIR /app
COPY . .
RUN dotnet build -c Release
ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]