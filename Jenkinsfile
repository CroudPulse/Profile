def profileImage

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
    // agent{
    //     docker { 
    //         image 'google/cloud-sdk:alpine' 
    //         args '-v $HOME:/home -w /home'    
    //     }
    // }
    stages {
    //     stage('Deploy') {
    //         steps {
    //             withCredentials([file(credentialsId: 'Jenkins-SA-Key-File', variable: 'FILE')]) {
    //                 sh '''
    //                 set +x
    //                 HOME=$WORKSPACE
    //                 gcloud auth activate-service-account --key-file $FILE
    //                 '''
    //             }
    //         }
    //     }
    // }
    // stages {
    //     stage('Prepare environment '){
    //         steps{
               

    //             //sh 'chmod +x ./dotnet-install.sh'
    //             // sh 'chmod +x ./gcloud-install.sh'
                
    //             //sh './dotnet-install.sh'

    //             withCredentials([file(credentialsId: 'Jenkins-SA-Key-File', variable: 'FILE')]) {
    //                 sh "gcloud auth activate-service-account --key-file $FILE"
    //             }

    //             // withCredentials([file(credentialsId: 'fluted-agency-265710', variable: 'GC_KEY')]) {
    //             //     sh("gcloud auth activate-service-account --key-file=${GC_KEY}")
    //             //     sh "google-cloud-sdk/bin/gcloud auth print-access-token | docker login -u oauth2accesstoken --password-stdin https://gcr.io"
    //             // }
    //         }
    //     }

        stage('Building image') {
            steps {
                script{
                    // Semantic versioning 
                    profileImage = docker.build('$registry/$project/$apiname:$major_version.$minor_version.$BUILD_NUMBER','--no-cache -f ./Profile/Dockerfile .')
                }
            }
        }
        
    //     stage('Pushing Image'){
    //         steps {
    //             script{
    //                 profileImage.push() 
    //             }   
    //         }
    //     }
    // }
}
              