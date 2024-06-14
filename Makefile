.include: .env

help:
	echo "Fuck"

#= Build Targets ===============================================================

watch:
	dotnet watch --project DomraSinForms.Client

watch-css:
	cd ./DomraSinForms.Client/ && \
	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css

#= Migrations targets ==========================================================

install-ef-tools:
	dotnet tool install --global dotnet-ef || exit 0
	dotnet tool update --global dotnet-ef
	dotnet ef

add-migration: NAME ?=
add-migration:
	dotnet ef migrations add "$(NAME)" \
		--project DomraSinForms.Persistence/DomraSinForms.Persistence.csproj \
		--startup-project ./DomraSinForms.Client/DomraSinForms.Client.csproj 

update-database:
	dotnet ef database update \
		--project DomraSinForms.Persistence/DomraSinForms.Persistence.csproj \
		--startup-project ./DomraSinForms.Client/DomraSinForms.Client.csproj

#= Database targets ============================================================
	
start-sql:
	@echo "This target will use sudo"
	@sudo docker-compose --file scripts/sql/docker-compose.yml up -d
	@echo "Postgresql on http://localhost:5432"
	@echo "PGAdmin on http://localhost:5050"
stop-sql:
	@echo "This target will use sudo"
	@sudo docker-compose --file scripts/sql/docker-compose.yml down
