import java.text.SimpleDateFormat

// pod utilisé pour la compilation du projet
podTemplate(label: 'wallboard-back-build-pod', nodeSelector: 'medium', containers: [
        // le slave jenkins
        containerTemplate(name: 'jnlp', image: 'jenkinsci/jnlp-slave:alpine'),
        // un conteneur pour le build dotnet
        containerTemplate(name: 'dotnet', image: 'microsoft/dotnet', ttyEnabled: true, command: 'cat'),
        // un conteneur pour construire les images docker
        containerTemplate(name: 'docker', image: 'docker:18.02', command: 'cat', ttyEnabled: true),
        // un conteneur pour déployer les services kubernetes
        containerTemplate(name: 'kubectl', image: 'lachlanevenson/k8s-kubectl', command: 'cat', ttyEnabled: true)],

        // montage nécessaire pour que le conteneur docker fonction (Docker In Docker)
        volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
) {

    node('wallboard-back-build-pod') {
        def now = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date())

        stage('checkout sources'){
            checkout scm
        }

        container('dotnet') {
            // opt out dotnet telemetry
            sh 'env DOTNET_CLI_TELEMETRY_OPTOUT=1'

            sh 'dotnet restore'
            sh 'dotnet build'

            // see issue https://github.com/Microsoft/vstest/issues/1129
            sh 'dotnet test ./WallboardBack.Tests/WallboardBack.Tests.csproj --no-build'

			sh 'dotnet publish -c Release -o out'
        }

        container('docker') {
            stage('build docker image') {
                    sh 'env DOTNET_CLI_TELEMETRY_OPTOUT=1'
                    sh "docker build -t registry.k8.wildwidewest.xyz/repository/docker-repository/pocs/wallboard-back:$now ."

                    sh 'mkdir /etc/docker'

                    // le registry est insecure (pas de https)
                    sh 'echo {"insecure-registries" : ["registry.k8.wildwidewest.xyz"]} > /etc/docker/daemon.json'

                    withCredentials([string(credentialsId: 'nexus_password', variable: 'NEXUS_PWD')]) {

                         sh "docker login -u admin -p ${NEXUS_PWD} registry.k8.wildwidewest.xyz"
                    }

                    sh "docker push registry.k8.wildwidewest.xyz/repository/docker-repository/pocs/wallboard-back:$now"
            }
        }

        container('kubectl') {
                build job: "wallboard-back-run/master",
                                  wait: false,
                                  parameters: [[$class: 'StringParameterValue', name: 'image', value: "$now"]]
	}
    }
}
