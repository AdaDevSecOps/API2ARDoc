def githubRepo = 'https://github.com/AdaDevSecOps/API2ARDoc.git'
def githubBranch = 'main'

pipeline
{
    agent any
    environment
    {
        imagename = "api2ardoc:5.20002.0.10"
        dockerImage = ''
    }
    stages{
        stage("Git Clone")
        {
            steps
            {
                echo "========Cloning Git========"
                git url: githubRepo,
                    branch: githubBranch
            }
            post
            {
                success
                {
                    echo "========Cloning Git successfully========"
                }
                failure
                {
                    echo "========Cloning Git failed========"
                }
            }
        }
        stage('Build Image')
        {
            steps
            {
                echo 'Building...'
                script
                {
                    dockerImage = docker.build imagename
                }
            }
        }
        stage('Remove Container')
        {
            steps
            {
                echo 'Remove Container...'
                script
                {
                    bat 'docker rm -f api2ardoc '
                }
            }
        }
        stage('Run Container')
        {
            steps
            {
                echo 'Run Container...'
                script
                {
                    bat 'docker run -d --name api2ardoc api2ardoc:5.20002.0.10 '
                }
            }
        }
    }
}
