pipeline 
{
    agent any
	parameters 
	{
			string(	name: 'SOLUTION_FILE',
					defaultValue: "WebApplication2.sln", 
					description: 'Project Solution File')

			string(	name: 'TEST_FILE',
					defaultValue: "XUnitTestProject1/WebApiXUnitTest.csproj", 
					description: 'Project Unit Test File')

            string( name: 'DOCKER_USERNAME',
                    defaultValue: "rneelesh299", 
                    description: 'Docker Account Username')

            string( name: 'DOCKER_PASSWORD',
                    defaultValue: "Admin@123", 
                    description: 'Docker Account Password')

            string( name: 'DOCKER_IMAGE',
                    defaultValue: "WebAPI_image", 
                    description: 'Docker Image Name')

            string( name: 'DOCKER_REPOSITORY',
                    defaultValue: "rneelesh299/training_repo", 
                    description: 'Docker Account Repository')

            string( name: 'DOCKER_TAG',
                    defaultValue: "tagname", 
                    description: 'Docker Image Tag')
    }
	
    stages 
    {
    	stage('Restore') 
        {
            steps 
            {
                echo '_________________________ RESTORE ________________________________'
				bat 'dotnet restore %SOLUTION_FILE% --source https://api.nuget.org/v3/index.json'            
            }
        }
        stage('Build') 
        {
            steps 
            {
                echo '_________________________ BUILD ________________________________'
                bat 'dotnet build %SOLUTION_FILE% -p:Configuration=release -v:n'
            }
        }
        stage('Test') 
        {
            steps 
            {
                echo '_________________________ TEST ________________________________'
                bat 'dotnet test %TEST_FILE%'
            }
        }
        stage('PUBLISH')
        {
            steps 
            {
                echo '_________________________ PUBLISH ________________________________'
                bat 'dotnet publish %SOLUTION_FILE% -c RELEASE -o Publish'
            }
        }
        stage('BUILD DOCKER IMAGE')
        {
            steps 
            {
                echo '_________________________ BUILD DOCKER IMAGE ________________________________'
                bat 'docker build -t %DOCKER_IMAGE% -f Dockerfile .'               
            }
        }
        stage('DOCKER USER LOGIN')
        {
            steps 
            {
                echo '_________________________ DOCKER USER LOGIN ________________________________'
                bat 'docker login -p %DOCKER_PASSWORD% -u %DOCKER_USERNAME%'
            }
        }
        stage('DOCKER PUSH IMAGE TO DOCKERHUB')
        {
            steps 
            {
                echo '__________________ DOCKER PUSH IMAGE TO DOCKERHUB ________________________'
                bat 'docker tag %DOCKER_IMAGE% %DOCKER_REPOSITORY%:%DOCKER_TAG%'
                bat 'docker push %DOCKER_REPOSITORY%:%DOCKER_TAG%'
            }
        }


        }
        stage('REMOVE OLD IMAGE')
        {
            steps 
            {
                echo '_________________________ REMOVE OLD IMAGE ________________________________'
                bat 'docker rmi %DOCKER_IMAGE%:latest'
                bat 'docker rmi %DOCKER_REPOSITORY%:%DOCKER_TAG%'
            }
        }
        stage('DOCKER IMAGE RUN')
        {
            steps 
            {
                echo '_________________________ DOCKER IMAGE RUN ________________________________'
                bat 'docker pull %DOCKER_REPOSITORY%:%DOCKER_TAG%'   
                bat 'docker run --rm -p 6069:5000 %DOCKER_REPOSITORY%:%DOCKER_TAG% '   
            }

        }
    }
}
