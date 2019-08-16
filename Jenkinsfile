pipeline {
    agent any
	parameters {		
			string(	name: 'GIT_PATH',
					defaultValue: "https://github.com/tavisca-nrajpurohit/WebAPI2.git",
					description: '')

			string(	name: 'SOLUTION_FILE',
					defaultValue: "WebApplication2.sln", 
					description: '')

			string(	name: 'TEST_FILE',
					defaultValue: "XUnitTestProject1/ValuesControllerFixture.cs", 
					description: '')
    }
	
    stages {
        stage('Build') {
            steps {
				bat 'dotnet restore WebApplication2.sln --source https://api.nuget.org/v3/index.json'
                bat 'dotnet build  WebApplication2.sln -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test XUnitTestProject1/WebApiXUnitTest.csproj'
            }
        }
	    
	      stage('Deploy') {
            steps {
				bat 'dotnet publish WebApplication2.sln -o Publish'
            }
        }
    }
}
