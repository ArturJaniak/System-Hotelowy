FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]
ENTRYPOINT ["dnx", ".", "run"]