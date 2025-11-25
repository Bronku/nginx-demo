package java_app.spring_boot;

import jakarta.servlet.http.HttpServletRequest;
import org.springframework.http.HttpHeaders;
import org.springframework.web.bind.annotation.*;

@RestController
public class MirrorController {

    private final String serverName = System.getenv().getOrDefault(
        "NAME",
        "unnamed"
    );

    @GetMapping(path = "/**") // Obsługuje dowolną ścieżkę
    public String mirrorRequest(HttpServletRequest request) {
        String ip = request.getRemoteAddr();
        String method = request.getMethod();
        String scheme = request.getScheme();
        String host = request.getHeader(HttpHeaders.HOST);
        String path = request.getRequestURI();
        String queryString = request.getQueryString() != null
            ? "?" + request.getQueryString()
            : "";

        StringBuilder responseText = new StringBuilder();

        responseText.append("Server Name: ").append(serverName).append("\n");
        responseText.append("IP Address (Remote): ").append(ip).append("\n");
        responseText.append("Method: ").append(method).append("\n");
        responseText.append("Scheme: ").append(scheme).append("\n");
        responseText.append("Host: ").append(host).append("\n");
        responseText.append("Path: ").append(path).append("\n");
        responseText.append("QueryString: ").append(queryString).append("\n");
        responseText.append("Headers:\n");

        request
            .getHeaderNames()
            .asIterator()
            .forEachRemaining(headerName -> {
                responseText
                    .append("  ")
                    .append(headerName)
                    .append(": ")
                    .append(request.getHeader(headerName))
                    .append("\n");
            });

        return "<pre>" + responseText.toString() + "</pre>\n";
    }
}
