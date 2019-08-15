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
				sh 'dotnet restore ${SOLUTION_FILE} --source https://api.nuget.org/v3/index.json'
                sh 'dotnet build  ${SOLUTION_FILE} -p:Configuration=release -v:n'
            }
        }
        stage('Test') {
            steps {
                sh 'dotnet test ${TEST_FILE}'
            }
        }
	    
	      stage('Deploy') {
            steps {
				sh 'dotnet publish ${SOLUTION_FILE_PATH} -o Publish'
            }
        }
    }
}
