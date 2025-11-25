echo "Testing .NET app routing (load balancing):"
for i in {1..10}; do
  curl -s -H "X-App-Type: dotnet" http://localhost/ | grep "Server Name"
  sleep 0.1
done

echo ""
echo "Testing Java app routing (load balancing):"
for i in {1..10}; do
  curl -s -H "X-App-Type: java" http://localhost/ | grep "Server Name"
  sleep 0.1
done

echo ""
echo "Waiting 3 seconds before rate limiting test..."
sleep 3

echo "Testing rate limiting (50 rapid requests):"
success=0
limited=0
for i in {1..50}; do
  response=$(curl -H "X-App-Type: dotnet" http://localhost/ -w "%{http_code}" -s -o /dev/null)
  if [ "$response" == "200" ]; then
    success=$((success + 1))
  elif [ "$response" == "503" ]; then
    limited=$((limited + 1))
  fi
done

echo "Results:"
echo "  Successful (200): $success"
echo "  Rate Limited (503): $limited"
