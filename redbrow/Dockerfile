
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 5265

COPY bin/Release/net7.0/publish .

ENTRYPOINT ["dotnet", "redbrow.dll"]