wget https://dl.google.com/dl/cloudsdk/release/google-cloud-sdk.tar.gz
tar zxvf google-cloud-sdk.tar.gz && ./google-cloud-sdk/install.sh

google-cloud-sdk/bin/gcloud auth activate-service-account --key-file $FILE
google-cloud-sdk/bin/gcloud auth print-access-token | docker login -u oauth2accesstoken --password-stdin https://gcr.io
google-cloud-sdk/bin/gcloud components install kubectl
google-cloud-sdk/bin/kubectl version --client=true
google-cloud-sdk/bin/gcloud container clusters get-credentials $cluster --zone $zone --project $project
google-cloud-sdk/bin/kubectl get po