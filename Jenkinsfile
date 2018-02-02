import java.text.SimpleDateFormat

// pod utilisé pour la compilation du projet
podTemplate(label: 'wallboard-back-build-pod', nodeSelector: 'medium', containers: [
        // le slave jenkins
        containerTemplate(name: 'jnlp', image: 'jenkinsci/jnlp-slave:alpine'),
        // un conteneur pour le build dotnet
        containerTemplate(name: 'dotnet', image: 'microsoft/dotnet', ttyEnabled: true, command: 'cat'),
        // un conteneur pour construire les images docker
        containerTemplate(name: 'docker', image: 'docker', command: 'cat', ttyEnabled: true),
        // un conteneur pour déployer les services kubernetes
        containerTemplate(name: 'kubectl', image: 'lachlanevenson/k8s-kubectl', command: 'cat', ttyEnabled: true)],

        // montage nécessaire pour que le conteneur docker fonction (Docker In Docker)
        volumes: [hostPathVolume(hostPath: '/var/run/docker.sock', mountPath: '/var/run/docker.sock')]
]) {

    node('wallboard-back-build-pod') {
        def now = new SimpleDateFormat("yyyyMMddHHmmss").format(new Date())

        stage('checkout sources'){
            checkout scm
        }

        container('dotnet') {
            sh 'dotnet restore'
            sh 'dotnet build'
            sh 'dotnet test'
        }

        container('docker') {
        }

        container('kubectl') {
        }
    }
}
