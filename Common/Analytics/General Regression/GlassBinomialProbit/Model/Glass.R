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
# install.packages("MASS")
# install.packages("ROCR")
# install.packages("caret")
# install.packages("e1071")

# Load below packages
library(pmml)
library(gmodels)
library(MASS)#This package is specifically loaded for fgl dataset shipped within it.
library(ROCR)
library(caret)
library(e1071)

# Here we directly load the glass dataset installed with the "MASS" package.
data(fgl)

# rename column names for fgl dataset from MASS package
glassOriginal <- setNames(fgl, c("Refractive_Index", "Sodium", "Magnesium", "Aluminium", "Silicon", "Potassium", "Calcium", "Barium", "Iron", "Type"))

# Omit rows with missing values
glassOriginal = na.omit(glassOriginal)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# glass= read.csv("Glass.csv")

# Frame the data. 
WinF = as.character(as.integer(glassOriginal$Type == 'WinF'))
glassOriginal = cbind(glassOriginal[, 1:9], WinF)

# Randomizing data
glass<- glassOriginal[sample(nrow(glassOriginal)),]

# Divide dataset for training and test
trainData<-glass[1:170,]
testData<-glass[171:214,]

# Applying General Regression Model - probit function to predict WinF type
glassFormula = formula(WinF~ .)
glass_GLM = glm(glassFormula, trainData, family = binomial(link="probit"))
summary(glass_GLM )

# Display the predicted results and create cross table to check on accuracy
# Predict "WinF" column probability for test data set
glassTestProbabilities = predict(glass_GLM, type = "response",testData)
# Display predicted probabilities
glassTestProbabilities

# Categorize the probability for predicted value (0/1)
glassTestPrediction= as.character(as.integer(glassTestProbabilities > 0.5))
# Display predicted values
glassTestPrediction

# Create cross table to check on accuracy.
CrossTable(glassTestPrediction,testData$WinF,  prop.chisq = FALSE, prop.t = FALSE, prop.r = FALSE,dnn = c('predicted', 'actual'))

# Generate ROC curve and calculate AUC value to predict the accuracy for Glass test dataset

# To create visualizations - ROC curve with "ROCR" package two vectors of data are needed, 
# The first vector must contain the class values - WinF column and
# The second vector must contain the estimated probability of the positive class(WindowFloatGlassTypeProbability)
pred <- prediction(labels = testData$WinF, predictions = glassTestProbabilities)

# Using the perf performance object, we can visualize the ROC curve with R's plot() function
perf <- performance(pred, measure = "tpr", x.measure = "fpr")

# Plot the ROC curve for the visualization 
plot(perf, main = "ROC curve for Glass Test Dataset", col = "blue", lwd = 3)

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
# Below AUC value is under the "excellent/good" category 
unlist(perf.auc@y.values)

# View Specificity, Sensitivity and Accuracy information using confusionMatrix function from "caret" package
confusionMatrix(glassTestPrediction,testData$WinF, positive = "1")

# PMML generation
pmmlFile<-pmml(glass_GLM,data=trainData)
write(toString(pmmlFile),file="Glass.pmml")
saveXML(pmmlFile,file="Glass.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original fgl data set and predicted results are saved in "ROutput.csv"
# "ROutput.csv" file used for comparing the R results with PMML Evaluation engine results

# Applying General Regression model to entire dataset and save the results in a CSV file
glassEntireProbabilities = predict(glass_GLM, type = "response",glassOriginal)

# Categorize the probability for predicted value (0/1)
glassEntirePrediction = as.character(as.integer(glassEntireProbabilities > 0.5))

# Save predicted value in a data frame
glassProbabilities = cbind(1 -glassEntireProbabilities,glassEntireProbabilities)
result = data.frame(glassEntirePrediction, glassProbabilities )
names(result) = c("Predicted_WindowFloatGlassType", "NonWindowFloatGlassTypeProbability", "WindowFloatGlassTypeProbability")

# Write the results in a CSV file
write.csv(result,"ROutput.csv",quote=F)
