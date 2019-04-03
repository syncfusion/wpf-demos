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
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("datasets")
# install.packages("ROCR")
# install.packages("caret")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(datasets) # This package is specifically loaded for iris dataset shipped within it.
library(ROCR)
library(caret)
library(e1071)

# Here we directly load the audit dataset installed with the "datasets" package.
data(iris)

# Rename column names in iris dataset from datasets package 
irisOriginal <- setNames(iris, c("Sepal_Length","Sepal_Width","Petal_Length","Petal_Width","Species"))

# Omit rows with missing values
irisOriginal = na.omit(irisOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# iris= read.csv("Iris.csv")

# Frame the data 
versicolor = as.character(as.integer(irisOriginal$Species == 'versicolor'))
irisOriginal = cbind(irisOriginal[, 1:4], versicolor)

# Randomizing data
iris<- irisOriginal[sample(nrow(irisOriginal)),]

# Divide dataset for training and test
trainData<-iris[1:120,]
testData<-iris[121:150,]

# Applying General Regression Model - logit function to predict versicolor
irisFormula = formula(versicolor ~ .)
iris_GLM = glm(irisFormula, trainData, family = quasibinomial(link="probit"))

# Display the predicted results and create cross table to check on accuracy
# Predict "Species_versicolor" column probability for test data set
irisTestProbabilities = predict(iris_GLM,type = "response",testData)
# Display predicted probabilities
irisTestProbabilities

# Categorize the probability for predicted value (0/1)
irisTestPrediction= as.character(as.integer(irisTestProbabilities > 0.5))
# Display predicted value
irisTestPrediction

# Create cross table to check on accuracy.
CrossTable(irisTestPrediction,testData$versicolor,  prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,dnn = c('predicted', 'actual'))

# Generate ROC curve and calculate AUC value to predict the accuracy for Iris test dataset
 
# To create visualizations - ROC curve with "ROCR" package two vectors of data are needed, 
# The first vector must contain the class values - versicolor column and
# The second vector must contain the estimated probability of the positive class(VersicolorProbability)
pred <- prediction(labels = testData$versicolor, predictions = irisTestProbabilities)

# Using the perf performance object, we can visualize the ROC curve with R's plot() function
perf <- performance(pred, measure = "tpr", x.measure = "fpr")

# Plot the ROC curve for the visualization 
plot(perf, main = "ROC curve for Iris Test Dataset", col = "blue", lwd = 3)

# To indicate reference line in the ROC plot
abline(a = 0, b = 1, lwd = 2, lty = 2)

# We can use the ROCR package to calculate the AUC(Area under the ROC Curve)
# To do so, we first need to create another performance object and specify measure = "auc", as shown in the following code:
perf.auc <- performance(pred, measure = "auc")

# perf.auc is an object (specifically known as an S4 object) we need to use a special type of notation to access the values stored within.
# S4 objects hold information in positions known as slots
# The str() function can be used to see all slots for an object
str(perf.auc)

# To access the AUC value, which is stored as a list in the y.values slot, we can use the @ notation along with the unlist() function, which simplifies lists to a vector of numeric values
# Below AUC value is under the "acceptable/fair" category 
unlist(perf.auc@y.values)

# View Specificity, Sensitivity and Accuracy information using confusionMatrix function from "caret" package
confusionMatrix(irisTestPrediction,testData$versicolor, positive = "1")

# PMML generation
pmmlFile<-pmml(iris_GLM,data=trainData)
write(toString(pmmlFile),file="Iris.pmml")
saveXML(pmmlFile,file="Iris.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original iris data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
irisEntireProbabilities = predict(iris_GLM, type = "response",irisOriginal)

# Categorize the probability for predicted value (0/1)
irisEntirePrediction = as.character(as.integer(irisEntireProbabilities > 0.5))

# Save predicted value in a data frame
irisProbabilities = cbind(1 - irisEntireProbabilities, irisEntireProbabilities)
result = data.frame(irisEntirePrediction, irisProbabilities)
names(result) = c("Predicted_Species", "NonVersicolorProbability", "VersicolorProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)


