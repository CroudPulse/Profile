export CLOUDSDK_CORE_DISABLE_PROMPTS=1; 
RUN apk add --update \
 python \
 curl \
 which \
 bash
curl -s https://sdk.cloud.google.com | bash