# Copyright Syncfusion Inc. 2001 - 2016. All rights reserved.
# Use of this code is subject to the terms of our license.
# A copy of the current license can be obtained at any time by e-mailing
# licensing@syncfusion.com. Any infringement will be prosecuted under
# applicable laws. 


# If you are not familiar with R you can obtain a quick introduction by downloading
# R Succinctly for free from Syncfusion - http://www.syncfusion.com/resources/techportal/ebooks/rsuccinctly
# R Succinctly is also included with this installation and is available here
# Installed Drive :\Program Files (x86)\Syncfusion\Essential Studio\XX.X.X.XX\Infrastructure\EBooks\R_Succintly.pdf OF R Succinctly
# Uncomment below lines to install necessary packages if not installed already
# install.packages("rattle")
# install.packages("pmml")  
# install.packages("datasets") 

# Load below packages
library(rattle)
library(pmml) 
library(datasets) # This package is specifically loaded for iris dataset shipped within it.

# Here we directly load the iris dataset installed with the "datasets" package.
data(iris)

# rename column names for iris dataset from datasets package
irisOriginal <- setNames(iris, c("Sepal_Length","Sepal_Width","Petal_Length","Petal_Width","Species"))

# Omit rows with missing values
irisOriginal <- na.omit(irisOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# iris<- read.csv("Iris.csv")

# Get numeric fields data of glass
numericIrisData<- irisOriginal[,c("Sepal_Length","Sepal_Width","Petal_Length","Petal_Width")]

# Randomizing data
iris<- numericIrisData[sample(nrow(numericIrisData)),]

# Divide dataset for training and test
trainData<-iris[1:120,]
testData<-iris[121:150,]

# Applying KMeans Clustering algorithm with centroids "3"
iris_KMeans <- kmeans(trainData,3)
iris_KMeans

# Predict "Species" column for test data set
irisTestPrediction<-predict(iris_KMeans,testData)
# Display predicted values
irisTestPrediction


# PMML generation
pmmlFile<-pmml(iris_KMeans,data=trainData)
write(toString(pmmlFile),file="Iris.pmml")
saveXML(pmmlFile,file="Iris.pmml")

# The code below is used for evaluation purpose.
# The model is applied for original Iris data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying KMeans clustering algorithm to entire dataset and save the results in a CSV file
irisEntirePrediction<-predict(iris_KMeans,numericIrisData)
irisEntirePrediction

# Save predicted value in a data frame
result <- data.frame(irisEntirePrediction)
names(result) <- c("Predicted_Species")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)

