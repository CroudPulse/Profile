def testImage

pipeline {  
    environment {
        registry = "gcr.io"
        project = "fluted-agency-265710"
        registryCredential = 'dockerhub'
        token = credentials('docker-token')
        gcloud_sdk = 'https://dl.google.com/dl/cloudsdk/release/google-cloud-sdk.tar.gz'
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

        stage('Download gcloud sdk'){
            steps{
                sh 'wget $gcloud_sdk'
                sh 'tar zxvf google-cloud-sdk.tar.gz && ./google-cloud-sdk/install.sh '
            }
        }
        
        stage('Prepare gcloud environment '){
            steps{
                withCredentials([file(credentialsId: 'Jenkins-SA-Key-File', variable: 'FILE')]) {
                    //sh 'cat $FILE'
                    sh 'google-cloud-sdk/bin/gcloud auth activate-service-account --key-file $FILE'
                    sh 'google-cloud-sdk/bin/gcloud auth print-access-token | docker login -u oauth2accesstoken --password-stdin https://gcr.io'
                }
            }
        }
        
        stage('Building image') {
            steps {
                script{
                    testImage = docker.build(registry + "/" + project + "/profile" + ":$BUILD_NUMBER","--no-cache -f ./Profile/Dockerfile .")
                }
            }
        }
        
        stage('Pushing Image'){
            steps {
                script{
                    testImage.push() 
                }   
            }
        }
    }
}
              