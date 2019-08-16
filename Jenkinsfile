pipeline 
{
    agent any
	parameters 
	{
			string(	name: 'SOLUTION_FILE',
					defaultValue: "WebApplication2.sln", 
					description: '')

			string(	name: 'TEST_FILE',
					defaultValue: "XUnitTestProject1/WebApiXUnitTest.csproj", 
					description: '')
    }
	
    stages 
    {
    	stage('Restore') 
        {
            steps 
            {
                bat '_________________________ RESTORE ________________________________'
				bat 'dotnet restore %SOLUTION_FILE% --source https://api.nuget.org/v3/index.json'            }
        }
        stage('Build') 
        {
            steps 
            {
                bat '_________________________ BUILD ________________________________'
                bat 'dotnet build %SOLUTION_FILE% -p:Configuration=release -v:n'
            }
        }
        stage('Test') 
        {
            steps 
            {
                bat '_________________________ TEST ________________________________'
                bat 'dotnet test %TEST_FILE%'
            }
        }
        stage('Publish')
        {
            steps 
            {
                bat '_________________________ PUBLISH ________________________________'
                bat 'dotnet publish %SOLUTION_FILE% -c RELEASE -o Publish'
            }
        }
        stage('Deploy')
        {
            steps 
            {
                bat '_________________________ DEPLOY ________________________________'
                bat 'docker build -t WebApiImage -f Dockerfile .'
                bat 'docker run WebApiImage -p 6069:5000'
            }
        }
    }
}
