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
# install.packages("kernlab")
# install.packages("pmml") 
# install.packages("gmodels") 
# install.packages("rpart.plot")
# install.packages("e1071")

# Load below packages
library(kernlab)
library(pmml)
library(rpart.plot) # This package is specifically loaded for ptitanic dataset shipped within it.
library(gmodels)

# Here we directly load the ptitanic dataset installed with the "pmml" package.
data(ptitanic)

# rename column names in ptitanic dataset from rpart.plot package
titanicOriginal <- setNames(ptitanic, c("Class", "Survived", "Sex", "Age", "Siblings", "Children"))

# Omit rows with missing values
titanicOriginal <- na.omit(titanicOriginal) 

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# titanic<- read.csv("Titanic.csv")

# Randomizing data
titanic<- titanicOriginal[sample(nrow(titanicOriginal)),]

# Divide dataset for training and test
trainData<-titanic[1:836,]
testData<-titanic[837:1046,]

## Applying Support vector Machine Function using Sigmoid kernel- "tanhdot"
titanic_SVM<-ksvm(Survived~.,data=trainData,kernel="tanhdot")
titanic_SVM

# Display the predicted results and create cross table to check on accuracy
# Predict "Survived" column for test data set
titanicTestPrediction<-predict(titanic_SVM,testData)
# Display predicted values
titanicTestPrediction

# Create cross table to check on accuracy.
CrossTable(testData$Survived,titanicTestPrediction,prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,
           dnn = c('actual', 'predicted'))

# PMML generation
pmmlFile<-pmml(titanic_SVM,data=trainData)
write(toString(pmmlFile),file="Titanic.pmml")
saveXML(pmmlFile,file="Titanic.pmml")

# The code below is used for evaluation purpose.
# The model is applied for original ptitanic data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying Support vector Machine model to entire dataset and save the results in a CSV file
titanicEntirePrediction<-predict(titanic_SVM,titanicOriginal)
titanicEntirePrediction

# Save predicted value in a data frame
result = data.frame(titanicEntirePrediction)
names(result) = c("Predicted_Survived")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)