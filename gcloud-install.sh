
export CLOUDSDK_CORE_DISABLE_PROMPTS=1; 
USER root
apk add --update curl 
curl -s https://sdk.cloud.google.com | sh

# google-cloud-sdk/bin/gcloud auth activate-service-account --key-file $FILE
#apt-get update && sudo apt-get install google-cloud-sdk
# google-cloud-sdk/bin/gcloud auth print-access-token | docker login -u oauth2accesstoken --password-stdin https://gcr.io