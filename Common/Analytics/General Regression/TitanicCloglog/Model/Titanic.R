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
# install.packages("rpart.plot")
# install.packages("ROCR")
# install.packages("caret")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(rpart.plot)# This package is specifically loaded for ptitanic dataset shipped within it.
library(ROCR)
library(caret)
library(e1071)

# Here we directly load the ptitanic dataset installed with the "rpart.plot" package.
data(ptitanic)

# rename column names in ptitanic dataset from rpart.plot package
titanicOriginal <- setNames(ptitanic, c("Class", "Survived", "Sex", "Age", "Siblings", "Children"))

# Omit rows with missing values
titanicOriginal = na.omit(titanicOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# titanic= read.csv("Titanic.csv")

# Frame the data. 
Survived = as.character(as.integer(titanicOriginal$Survived == 'survived'))
titanic = cbind(titanicOriginal[, 1:6], Survived)

# Randomizing data
titanic<- titanicOriginal[sample(nrow(titanicOriginal)),]

# Divide dataset for training and test
trainData<-titanic [1:836,]
testData<-titanic[837:1046,]

# Applying General Regression Model - cloglog function to predict Survived
titanicFormula = formula(Survived~Sex+Age+Siblings+Children)
titanic_GLM = glm(titanicFormula ,trainData , family = binomial(link="cloglog"))

# Display the predicted results and create cross table to check on accuracy
# Predict "Survived" column probability for test data set
titanicTestProbabilities = predict(titanic_GLM, type = "response",testData)
# Display predicted probabilities
titanicTestProbabilities

# Categorize the probability for predicted value(0/1)
titanicTestPrediction= as.character(as.integer(titanicTestProbabilities > 0.5))
# Display predicted values
titanicTestPrediction

# Create cross table to check on accuracy.
CrossTable(titanicTestPrediction,testData$Survived,  prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,dnn = c('predicted', 'actual'))

# Generate ROC curve and calculate AUC value to predict the accuracy for Titanic test dataset

# To create visualizations - ROC curve with "ROCR" package two vectors of data are needed, 
# The first vector must contain the class values - Survived column and
# The second vector must contain the estimated probability of the positive class(PassengerSurvivedProbability)
pred <- prediction(labels = testData$Survived, predictions = titanicTestProbabilities)

# Using the perf performance object, we can visualize the ROC curve with R's plot() function
perf <- performance(pred, measure = "tpr", x.measure = "fpr")

# Plot the ROC curve for the visualization 
plot(perf, main = "ROC curve for Titanic Test Dataset", col = "blue", lwd = 3)

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

# Convert character to integer
testData$Survived = as.character(as.integer(testData$Survived == 'died'))

# View Specificity, Sensitivity and Accuracy information using confusionMatrix function from "caret" package
confusionMatrix(titanicTestPrediction,testData$Survived, positive = "1")

# PMML generation
pmmlFile<-pmml(titanic_GLM,data=trainData)
write(toString(pmmlFile),file="Titanic.pmml")
saveXML(pmmlFile,file="Titanic.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original ptitanic data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
titanicEntireProbabilities = predict(titanic_GLM, type = "response",titanicOriginal)

# Categorize the probability for predicted value (0/1)
titanicEntirePrediction = as.character(as.integer(titanicEntireProbabilities > 0.5))

# Save predicted value in a data frame
titanicProbabilities = cbind(1 -titanicEntireProbabilities,titanicEntireProbabilities)
result = data.frame(titanicEntirePrediction, titanicProbabilities )
names(result) = c("Predicted_Survived", "PassengerDiedProbability", "PassengerSurvivedProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
