USER root
export CLOUDSDK_CORE_DISABLE_PROMPTS=1; 
apk add --update \
 python \
 curl \
 which \
 bash
curl -s https://sdk.cloud.google.com | bash