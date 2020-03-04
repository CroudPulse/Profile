// pipeline {
//    agent any

//    stages {
//         stage('Checkout') {
//             steps {
//                 git branch: 'master', url: 'https://github.com/CroudPulse/Profile.git'
//             }
//         }
      
//         stage('Restore packages'){
//             steps{
//                 sh "dotnet restore Profile.sln"
//             }
//         }
//         stage('Clean'){
//             steps{
//                 sh "dotnet clean Profile.sln"
//             }
//         }
        
//         stage('Build'){
//             steps{
//               sh "dotnet build Profile.sln --configuration Release"
//             }
//         }
        
//         stage('Publish'){
//             steps{
//                 sh "dotnet publish Profile.sln -c Release"
//             }
//         }
//    }
// }


pipeline {  
    environment {
        registry = "gcr.io"
        project = "fluted-agency-265710"
        registryCredential = 'dockerhub'
    }  
    agent any  
    
    stages {
        stage('Checkout') {
            steps {
                git branch: 'master', url: 'https://github.com/CroudPulse/Profile.git'
            }
        }
        stage('Clean Repository') {
            steps {
                sh "dotnet clean Profile.sln"
            }
        }
        stage('Building image') {
            steps {
                script {
                    def testImage = docker.build(registry + "/" + project + "/profile" + ":$BUILD_NUMBER","-f ./Profile/Dockerfile .")
                    testImage.push()
                }
            }
        }
    }
}
              