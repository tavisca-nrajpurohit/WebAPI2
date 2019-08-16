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
				bat 'dotnet restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json'
                bat 'dotnet build  ${SOLUTION_FILE} -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test ${TEST_FILE}'
            }
        }
	    
	      stage('Deploy') {
            steps {
				bat 'dotnet publish ${SOLUTION_FILE_PATH} -o Publish'
            }
        }
    }
}
