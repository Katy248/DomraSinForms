ServerProject := "DomraSinForms.Server"
ServerProjectFile := "./src/Server" / "DomraSinForms.Server" + ".csproj"
ClientProject := "DomraSinForms.Client"
ClientProjectFile := "./src/Client" / ClientProject + ".csproj"

export DOTNET_WATCH_RESTART_ON_RUDE_EDIT := "true"

[private]
default: help

#= Build Targets ===============================================================

[group('build')]
publish:
    dotnet publish {{ ClientProject }} \
    	--configuration Release \
    	--no-selfcontained \
    	--use-current-runtime \
    	--output bin/publish 

[group('build')]
watch:
    dotnet watch --project {{ ClientProjectFile }}

[group('build')]
[doc('Watch tailwindcss. Deprecated')]
watch-css:
    cd ./src/Client/ && \
    	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css

[group('build')]
[doc('Run server project')]
run-server:
    dotnet run --project {{ ServerProjectFile }}

#= Migrations targets ==========================================================

[group('migrations')]
install-ef-tools:
    @echo "Installing tools"
    @dotnet tool install --global dotnet-ef || exit 0
    @echo "Installed"
    @echo "Updating tools"
    @dotnet tool update --global dotnet-ef
    @echo "Updated"
    @dotnet ef --version

[group('migrations')]
[doc('Creates a new migration with specified name')]
add-migration MigrationName:
    dotnet ef migrations add {{MigrationName}} \
    	--project			./src/Persistence/DomraSinForms.Persistence.csproj \
    	--startup-project	{{ ClientProjectFile }}

[group('migrations')]
update-database:
    dotnet ef database update \
    	--project			./src/Persistence/DomraSinForms.Persistence.csproj \
    	--startup-project	{{ ClientProjectFile }}

#= Database targets ============================================================

[group('db-service')]
[unix]
[confirm('This target will use sudo, ok? [y/n]')]
start-sql:
    @sudo docker-compose up -d
    @echo "Postgresql on http://localhost:5432"
    @echo "PGAdmin on http://localhost:5050"

[group('db-service')]
[unix]
[confirm('This target will use sudo, ok? [y/n]')]
stop-sql:
    @sudo docker-compose down

#= Utils targets ===============================================================

[group('utils')]
env-file:
    @cp ./examples/example.env .env
    @echo ".env file created"

#= Help targets ================================================================

[group('help')]
[doc('Print this help message')]
help:
    @just --list --color always --unsorted --list-heading $'DSF Justfile\nRecipes:\n'
