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

add-migration: NAME ?=
add-migration:
	dotnet ef migrations add "$(NAME)" \
		--project DomraSinForms.Persistence/DomraSinForms.Persistence.csproj \
		--startup-project ./DomraSinForms.Client/DomraSinForms.Client.csproj 

update-database:
	dotnet ef database update \
		--project DomraSinForms.Persistence/DomraSinForms.Persistence.csproj \
		--startup-project ./DomraSinForms.Client/DomraSinForms.Client.csproj

install-sql-server-rpm:
	@figlet -c "Install SQL Server"
	sudo dnf config-manager --add-repo https://packages.microsoft.com/config/sles/15/mssql-server-2022.repo
	sudo dnf install -y mssql-server
	sudo /opt/mssql/bin/mssql-conf setup
	systemctl status mssql-server

	@figlet -c "Install SQL Server Cli Tools"
	curl https://packages.microsoft.com/config/rhel/8/prod.repo | sudo tee /etc/yum.repos.d/mssql-release.repo
	sudo yum install -y mssql-tools18 unixODBC-devel
	
	@figlet -c "Allow remote connection"
	sudo firewall-cmd --zone=public --add-port=1433/tcp --permanent
	sudo firewall-cmd --reload
	echo 'export PATH="$$PATH:/opt/mssql-tools18/bin"' >> ~/.bash_profile

.include: .env

SQL_SERVER_CONTAINER_NAME := sql-server
start-sql-server-docker:
	sudo docker run \
		-e "ACCEPT_EULA=Y" \
		-e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" \
		-p 1433:1433 \
		--name $(SQL_SERVER_CONTAINER_NAME) \
		--hostname $(SQL_SERVER_CONTAINER_NAME) \
		-d \
		mcr.microsoft.com/mssql/server:2022-latest

kill-sql-server-docker:
	sudo docker container stop $$(sudo docker container ls -f name=sql-server -q)
	sudo docker container rm $$(sudo docker container ls -f name=sql-server -q -a)

install-postgre:
	@echo ""
	@echo "Run as root"
	@echo ""
	
	dnf install -y postgresql-server postgresql-contrib
	systemctl enable postgresql
	postgresql-setup --initdb --unit postgresql
	systemctl start postgresql
	systemctl status postgresql
	
