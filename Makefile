help:
	echo "Fuck"

watch:
	dotnet watch --project DomraSinForms.Client

watch-css:
	cd ./DomraSinForms.Client/ && \
	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css

install-ef-tools:
	dotnet tool install --global dotnet-ef || exit 0
	dotnet tool update --global dotnet-ef
	dotnet ef

make-migration: NAME ?=
make-migration:
	dotnet ef migrations add "$(NAME)"