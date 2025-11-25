FROM maven:3.9.6-eclipse-temurin-21

WORKDIR /app
COPY . .

RUN mvn clean package -DskipTests

ENTRYPOINT ["java","-Dserver.port=80", "-jar", "target/spring-boot-0.0.1-SNAPSHOT.jar"]
