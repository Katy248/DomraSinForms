#=                        ======================================================
#= DomraSinForms Makefile ======================================================
#==== by Katy248 ===============================================================

include .env
export

ServerProject = DomraSinForms.Server
ClientProject = DomraSinForms.Client
ClientProjectFile = ./src/Client/$(ClientProject).csproj


all default: help

#= Build Targets ===============================================================

publish:
	dotnet publish \
		--configuration Release \
		--no-selfcontained \
		--use-current-runtime \
		--output bin/publish
		$(ClientProject)

watch:
	dotnet watch --project $(ClientProjectFile)

watch-css:
	cd ./src/Client/ && \
	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css

#= Migrations targets ==========================================================

install-ef-tools:
	@echo "Installing tools"
	@dotnet tool install --global dotnet-ef || exit 0
	@echo "Installed"
	@echo "Updating tools"
	@dotnet tool update --global dotnet-ef
	@echo "Updated"
	@dotnet ef --version

add-migration: NAME ?=
add-migration:
	dotnet ef migrations add "$(NAME)" \
		--project			./src/Persistence/DomraSinForms.Persistence.csproj \
		--startup-project	$(ClientProjectFile)

update-database:
	dotnet ef database update \
		--project			./src/Persistence/DomraSinForms.Persistence.csproj \
		--startup-project	$(ClientProjectFile)

#= Database targets ============================================================
	
start-sql:
	@echo "This target will use sudo"
	@sudo docker-compose up -d
	@echo "Postgresql on http://localhost:5432"
	@echo "PGAdmin on http://localhost:5050"

stop-sql:
	@echo "This target will use sudo"
	@sudo docker-compose down

#= Utils targets ===============================================================

env-file: .env
	@echo ".env file created"

.env: examples/example.env
	@cp $< $@

#= Help targets ================================================================

HelpScript := ./scripts/make

help:
	@sh ./scripts/make/help.sh

help-md:
	@MD=1 sh ./scripts/make/help.sh

#= Stupid targets ====

notify:
	notify-send \
		"Cool test" \
		"Cool test notification" \
		--action=default="Default text" \
		--action=second="Another action" \
		--action=third="Third action" \
		--transient

.PHONY: help help-md \
	publish watch watch-css \
	install-ef-tools add-migration update-database \
	start-sql stop-sql env-file
