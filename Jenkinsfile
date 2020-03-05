def testImage

pipeline {  
    environment {
        cluster = "istio-playground"
        zone = "us-central1-a"
        project = "fluted-agency-265710"
        apiname = "profile"
        registry = "gcr.io"
        registryCredential = 'dockerhub'
        token = credentials('docker-token')
        gcloud_sdk = 'https://dl.google.com/dl/cloudsdk/release/google-cloud-sdk.tar.gz'
        major_version = "0"
        minor_version = "0"
    }  
    agent any  
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
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
                    sh 'google-cloud-sdk/bin/gcloud components install kubectl'
                    sh 'google-cloud-sdk/bin/kubectl version --client=true'
                    sh 'google-cloud-sdk/bin/gcloud container clusters get-credentials $cluster --zone $zone --project $project'
                    sh 'google-cloud-sdk/bin/kubectl get po'
                }
            }
        }
        
        stage('Building image') {
            steps {
                script{
                    // Semantic versioning 
                    testImage = docker.build('$registry/$project/$apiname:$major_version.$minor_version.$BUILD_NUMBER','--no-cache -f ./Profile/Dockerfile .')
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
              