pipeline {
   agent any

   stages {
        stage('Checkout') {
            steps {
                git branch: 'master', url: 'https://github.com/CroudPulse/Profile.git'
            }
        }
      
        stage('Restore packages'){
            steps{
                sh "dotnet restore Profile.sln"
            }
        }
        stage('Clean'){
            steps{
                sh "dotnet clean Profile.sln"
            }
        }
        
        stage('Build'){
            steps{
              sh "dotnet build Profile.sln --configuration Release"
            }
        }
        
        stage('Publish'){
            steps{
                sh "dotnet publish Profile.sln -c Release"
            }
        }
   }
}
