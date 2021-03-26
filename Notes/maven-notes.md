# Maven

## versions
exec-maven-plugin - 1.6.0
maven-compiler-plugin - 3.8

## Maven commands
> mvn -version          # prints maven version
> mvn clean             # deletes build artifacts
> mvn compile           # compiles source code
> mvn compile-test      # compiles test code
> mvn clean compile     # cleans then compiles (common)
> mvn install           # builds then installs artifact in local repository
> mnv -o clean          # doesn't check for new updates
> mvn help:effective-pom # check effective POM
> mvn dependency:tree
> mvn package –Dmaven.test.skip=true


## Maven project generation
> mvn archtype:generate
### Example
> mvn archetype:generate -DgroupId=com.leroy.java.app -DartifactId=com.leroy.java.app -DarchetypeArtifactId=maven-archetype-quickstart -DinteractiveMode=false

 Produces:

 ``` xml
<project>
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.leroy.java.app</groupId>
    <artifactId>com.leroy.java.app</artifactId>
    <packaging>jar</packaging>
    <version>1.0-SNAPSHOT</version>
    <name>com.leroy.java.app</name>
    <url>http://maven.apache.org</url>
    <dependencies>
        <dependency>
            <groupId>junit</groupId>
            <artifactId>junit</artifactId>
            <version>3.8.1</version>
            <scope>test</scope>
        </dependency>
    </dependencies>
</project>
```

- Create a jar failure

> mvn clean package

- Run

> java -cp target\com.leroy.java.app-1.0-SNAPSHOT.jar com.leroy.java.app.App

> mvn clean

## Lifecycle

prepare-recources

validate

compile

test

package

install

deploy

## Naming

- groupId     # Id of group the produced the projec: com.leroy.java

- artifactId  # Id of project, name of app or jar

- version     # Verison of the project

- produces artifact:  groupId:artifactId:version

## Failure

- -fae, --fail-at-end   # fails the build after all modules are build; allow all non-impacted builds to continue

- -ff,  --fail-fast     # Stop at first module build failure

- -fn,  --fail-never    # NEVER fail the build, regardless of module build result

## Maven wrapper

> cd {your-project}

> mvn -N io.takari:maven:wrapper

> ./mvnw clean package

or

> mvnw.cmd clean package
