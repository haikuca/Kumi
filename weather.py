from flask import Flask, request, jsonify
import json

app = Flask(__name__)

@app.route("/", methods=["POST"])
def save_joke():
    if request.method == "POST":
        payload = json.loads(request.data)
        print("[Joke logged]: " + payload["joke"])
        return jsonify({"message": "Joke successfully saved!"})

if __name__ == "__main__":
    app.run(port=8764)
