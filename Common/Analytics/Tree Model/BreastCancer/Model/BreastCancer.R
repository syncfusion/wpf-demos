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
# install.packages("rpart")
# install.packages("pmml")
# install.packages("gmodels")
# install.packages("TH.data")
# install.packages("ROCR")
# install.packages("caret")
# install.packages("e1071")

# Load below packages
library(rpart)
library(pmml)
library(gmodels)
library(TH.data) # This package is specifically loaded for GBSG2 dataset shipped within it.
library(ROCR)
library(caret)
library(e1071)

# Here we directly load the GBSG2 dataset installed with the "TH.data" package.
data(GBSG2)

# rename column names in GBSG2 dataset from TH.data package
breastCancerOriginal <- setNames(GBSG2, c("Hormonal_Therapy", "Age", "Menopausal_Status", "Tumor_Size", "Tumor_Grade", "Positive_Nodes", "Progesterone", "Estrogen_Receptor",
"Survival_Time", "Indicator"))

# Omit rows with missing values
breastCancerOriginal <- na.omit(breastCancerOriginal)

# Converting Ordered factor to normal factor
breastCancerOriginal$Tumor_Grade<-factor(breastCancerOriginal$Tumor_Grade, ordered = FALSE)

# Code below demonstrates loading the same dataset from a CSV file shipped with our installer.
# Please check installed samples (Data) location to set actual working directory 
# Uncomment below lines and comment out the code to read data from CSV file.
# setwd("C:/actual_data_location")
# cancer<- read.csv("BreastCancer.csv")

# Considering integer variable as factor
breastCancerOriginal[ , "Indicator"] = as.factor(breastCancerOriginal[ , "Indicator"])

# Randomizing data
cancer<-breastCancerOriginal[sample(nrow(breastCancerOriginal)),]

# Divide dataset for training and test
cancerTrain <- cancer[1:550, ]
cancerTest <- cancer[551:686, ]

# Applying TreeModel
cancerModel <- rpart(Indicator ~ ., data = cancerTrain)
cancerModel

# Display the predicted results and create cross table to check on accuracy.
# Predict "cens" column for test data set
cancerTestPrediction<- predict(cancerModel ,cancerTest, type="class")
# Display predicted values
cancerTestPrediction

# Create cross table to check on accuracy.
CrossTable(cancerTest$Indicator, cancerTestPrediction, prop.chisq=FALSE,prop.c=FALSE,prop.r=FALSE,dnn = c('actual values','predicted values'))     

# Predict the Probabilities for test dataset
cancerTestProbabilities = predict(cancerModel, newdata = cancerTest, threshold = 0, type = "prob")

# Generate ROC curve and calculate AUC value to predict the accuracy for BreastCancer test dataset
# To create visualizations - ROC curve with "ROCR" package two vectors of data are needed, 
# The first vector must contain the class values - cens column and
# The second vector must contain the estimated probability of the positive class(NonCensoredProbability)
pred <- prediction(labels = cancerTest$Indicator, predictions = cancerTestProbabilities[,2])

# Using the perf performance object, we can visualize the ROC curve with R's plot() function
perf <- performance(pred, measure = "tpr", x.measure = "fpr")

# Plot the ROC curve for the visualization 
plot(perf, main = "ROC curve for BreastCancer Test Dataset", col = "blue", lwd = 3)

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
confusionMatrix(cancerTestPrediction,cancerTest$Indicator, positive = "1")

# PMML generation
cancerPmml<- pmml(cancerModel, data = cancerTrain)
write (toString (cancerPmml), file="BreastCancer.pmml")
saveXML (cancerPmml, file="BreastCancer.pmml")

# The code below is used for evaluation purpose. 
# The model is applied for original breastCancer data set and predicted results are saved in "ROuput.csv"
# "ROuput.csv" file used for comparing the R results with PMML Evaluation engine results

# Apply model to entire dataset and write the results in a csv file
classes = predict(cancerModel, newdata = breastCancerOriginal, threshold = 0, type = "class")
probabilities = predict(cancerModel, newdata = breastCancerOriginal, threshold = 0, type = "prob")

# Save predicted value in a data frame
writeOutput = function(classes, probabilities, file)
{
 result = NULL
 if(is.null(probabilities))
  {
  result = data.frame(classes)
  names(result) = c("Indicator")
 } 
  else
 {
  result = data.frame(classes, probabilities)
  names(result) = c("Predicted_censored", "CensoredProbability", "NonCensoredProbability")
 }
 write.csv(result, file, quote=F)
}

# Write the results in a CSV file
writeOutput(classes, probabilities, "ROutput.csv")

