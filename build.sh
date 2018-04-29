cur_dir=`pwd` 
data_project_dir=src/GateKeeper.Data
startup_project_dir=src/GateKeeper.Api

if [ -z "$1" ]
    then
        echo "Building project"
        dotnet build
    else
        if [ $1 = "run" ]; then
            echo "Building and running project"
            dotnet run --project $startup_project_dir
        fi
        if [ $1 = "test" ]; then
            echo "Running unit tests"
            for filename in tests/*; do
                dotnet test $filename/*.csproj
            done
        fi
        if [ $1 = "watch" ]; then
            cd $startup_project_dir
            dotnet restore
            dotnet watch run
            cd $cur_dir
        fi
        if [ $1 = "database" ] && [ $2 = "update" ]; then
            cd $data_project_dir
            dotnet restore
            dotnet ef database update -s $cur_dir/$startup_project_dir
            cd $cur_dir
        fi
        if [ $1 = "migrations" ] && [ $2 = "add" ]; then
            cd $data_project_dir
            dotnet ef migrations add $3 -s $cur_dir/$startup_project_dir
            cd $cur_dir
        fi
        if [ $1 = "migrations" ] && [ $2 = "remove" ]; then
            cd $data_project_dir
            dotnet ef migrations remove -s $cur_dir/$startup_project_dir
            cd $cur_dir
        fi
fi

