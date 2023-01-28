
#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
#WORKDIR /inetpub/wwwroot
#COPY . .
#RUN dotnet restore
#RUN dotnet publish ./SystemHotelowyVerX/SystemHotelowyVer3.csproj -o /publish/
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "SystemHotelowyVer3.dll"]