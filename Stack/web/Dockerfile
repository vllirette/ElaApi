# docker build -t welcome-page .
# docker run --name welcome-page -d welcome-page
FROM python
COPY . /app
WORKDIR /app
RUN pip install flask
EXPOSE 5000
ENTRYPOINT ["python"]
CMD ["welcome.py"]

