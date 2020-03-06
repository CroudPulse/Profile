# sudo apt-get update
# sudo apt-get install apt-transport-https ca-certificates curl software-properties-common -y -qq
# curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add –
# sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu  $(lsb_release -cs)  stable" 
# sudo apt-get update
# sudo apt-get install docker-ce -y -qq


wget https://download.docker.com/linux/ubuntu/dists/bionic/pool/edge/amd64/containerd.io_1.2.0-1_amd64.deb
wget https://download.docker.com/linux/ubuntu/dists/bionic/pool/edge/amd64/docker-ce-cli_19.03.7~3-0~ubuntu-bionic_amd64.deb

dpkg -i /path/to/package.deb
systemctl enable dockers
systemctl start docker