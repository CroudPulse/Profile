def testImage

pipeline {  
    environment {
        cluster = "istio-playground"
        zone = "us-central1-a"
        project = "fluted-agency-265710"
        apiname = "profile"
        registry = "gcr.io"
        major_version = "0"
        minor_version = "0"
    }  
    agent any  
    
    stages {
        // stage('Prepare environment '){
        //     steps{
        //         //sh 'chmod +x ./dotnet-install.sh'
        //         //sh 'chmod +x ./gcloud-install.sh'
        //         //sh 'chmod +x ./docker-install.sh'
                
        //         //sh './dotnet-install.sh'
        //         //sh './docker-install.sh'

        //         // withCredentials([file(credentialsId: 'Jenkins-SA-Key-File', variable: 'FILE')]) {
        //         //     sh './gcloud-install.sh'
        //         // }

        //     }
        // }

        // stage('Clean Repository') {
        //     steps {
        //         sh "dotnet clean Profile.sln"
        //     }
        // }
        
        
        
        stage('Building image') {
            steps {
                script{
                    // Semantic versioning 
                    testImage = docker.build('$registry/$project/$apiname:$major_version.$minor_version.$BUILD_NUMBER','--no-cache -f ./Profile/Dockerfile .')
                }
            }
        }
        
        // stage('Pushing Image'){
        //     steps {
        //         script{
        //             testImage.push() 
        //         }   
        //     }
        // }
    }
}
              