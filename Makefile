help:
	echo "Fuck"

watch:
	dotnet watch --project DomraSinForms.Client

watch-css:
	cd ./DomraSinForms.Client/ && \
	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css
