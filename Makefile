help:
	echo "Fuck"
run:
	dotnet run --project DomraSin.Server

watch-css:
	cd ./DomraSinForms.Client/ && \
	npx tailwindcss --watch --minify -i style.css -o ./wwwroot/app.css