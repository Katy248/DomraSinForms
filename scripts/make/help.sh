bold=$(tput bold)
unbold=$(tput rmso)
italic=$(tput sitm)
reverse=$(tput rev)
normal=$(tput sgr0)
dark=$(tput setaf 8)
red=$(tput setaf 9)
green=$(tput setaf 10)
yellow=$(tput setaf 11)
cyan=$(tput setaf 14)
underline=$(tput smul)

section_title_color=$normal
code_color=$cyan
target_group_title_color=$normal
target_title_color=$green

print_target() {
    if [[ "$MD" == "" ]]; then
        printf "  ${bold}${target_title_color}%-15s${normal} $2\n" "$1"
    else
        echo ""
        printf -- "- ### ${bold}${target_title_color}$1${normal}\n"
        if [[ $2 ]]; then
            printf "\n  $2\n"
        fi
    fi
}
print_target_group() {
    if [[ $MD == "" ]]; then
        printf "${target_group_title_color}${bold}$1:${normal}\n"
    else
        echo ""
        printf "## ${target_group_title_color}${bold}$1${normal}\n"
    fi
}
print_target_info_title() {
    if [[ $MD == "" ]]; then 
        printf "    ${italic}$1:${normal}\n"
    else
        echo ""
        printf "### $1\n"
    fi
}
print_target_info_item() {
    if [[ $MD == "" ]]; then 
        printf "      $1\n"
    else
        echo ""
        printf "  $1\n"
    fi
}

echo "${bold}Makefile for DomraSinForms${normal} by ${italic}Katy${green}2${yellow}4${red}8${normal}"
echo ""


#= Targets ====

print_target_group "Migrations"

print_target "install-ef-tools" "Installs EntityFrameworkCore tools for migrations usage in project."
print_target "add-migration" "Creates a new migration with specified ${bold}${italic}name${normal}."

print_target_info_title "Parameters" 
print_target_info_item "NAME - ${bold}${italic}name${normal} for newmigration"
print_target_info_title "Usage"
print_target_info_item "${code_color}\`NAME=${bold}<name>${normal}${code_color} make add-migration\`${normal}"
print_target_info_title "Examples" 
print_target_info_item "${code_color}\`NAME=${bold}Migration0002${normal}${code_color} make add-migration\`${normal}"
print_target "update-database" "Applys all migrations to database."

print_target_group "Build"
print_target "publish"
print_target "watch" "Builds client project and run it with hot reload enabled."
print_target "watch-css" "Builds tailwindcss, minify it, and watch for changes to rebuild."

print_target_group "Database service"
print_target "start-sql" "Starts docker image with PostgreSQL. ${yellow}Trys to use \`sudo\`.${normal}"
print_target "stop-sql" "Stops database docker process. ${yellow}Trys to use \`sudo\`.${normal}"

print_target_group "Utilities"

print_target "env-file" "Creates ${italic}.env${normal} file from example file."


print_target_group "Help"
print_target "help" "Prints help message and exit."
print_target "help-md" "Prints help message with markdown format and exit."

