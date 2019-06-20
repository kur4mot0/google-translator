# google-translator

Project created to translate what you need from any supported language to LANG defined on your environment.

To run this project, please download them and run with Docker, like:

docker build -t <image_name_do_you_like> --build-arg KEY=<your_API_from_google_developers> --build-arg LANG=<target_language> .

For use: 
docker run <image_name_do_you_like> 'your text'
