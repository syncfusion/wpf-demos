#region Copyright Syncfusion Inc. 2001 - 2006
//
//  Copyright Syncfusion Inc. 2001 - 2006. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;

using Syncfusion.Grouping;
using Syncfusion.Collections.BinaryTree;

namespace CustomSummary
{
	public class Class1
	{

		

		private Syncfusion.Grouping.Engine engine1;
		private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		private System.Data.SqlClient.SqlConnection sqlConnection1;
		private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		private CustomSummary.DataSet1 dataSet11;
		private SummaryDescriptor sd0;
		private SummaryDescriptor sd1;
		private SummaryDescriptor sd2;
		private SummaryDescriptor sd3;


		void ReadXml(DataSet ds, string xmlFileName)
		{
			for (int n = 0; n < 10; n++)
			{
				if (File.Exists(xmlFileName))
				{
					ds.ReadXml(xmlFileName);
					break;
				}
				xmlFileName = @"..\" + xmlFileName;
			}
		}

		public void Run()
		{
			foreach (Element el in engine1.Table.DisplayElements)
			{
				Console.WriteLine(el.ToString());
				if (el is Syncfusion.Grouping.SummarySection)
				{
					// Cast summary to correct type before accessing idividual summary properties
					Console.WriteLine("Summaries:");
					ITreeTableSummary[] summaries = el.ParentGroup.GetSummaries(el.ParentTable);
					
					DoubleAggregateSummary d0 = (DoubleAggregateSummary) summaries[el.ParentTableDescriptor.Summaries.IndexOf(sd0)];
					Console.WriteLine("QuantityAverage = {0}", d0.Average);
					
					TotalSummary d1 = (TotalSummary) summaries[el.ParentTableDescriptor.Summaries.IndexOf(sd1)];
					Console.WriteLine("QuantityDistinctCount = {0}", d1.Total);

					DistinctInt32CountSummary d2 = (DistinctInt32CountSummary) summaries[el.ParentTableDescriptor.Summaries.IndexOf(sd2)];
					Console.WriteLine("QuantityTotal = {0}", d2.Count);

					StatisticsSummary d3 = (StatisticsSummary) summaries[el.ParentTableDescriptor.Summaries.IndexOf(sd3)];
					Console.WriteLine("QuantityMedian = {0}", d3.Median);

                    Console.WriteLine("QuantityAverage = {0}", GetAverageSummary(sd0, el.ParentGroup));
				}
			}
		}

        string GetAverageSummary(SummaryDescriptor summaryDescriptor, Group group)
        {
            Table table = group.ParentTable;
            TableDescriptor td = table.TableDescriptor;
            string summaryText = "";

            bool use31Code = true;
            if (use31Code)
            {
                // Option 1: Strong typed access to DoubleAggregateSummary.
                DoubleAggregateSummary summary1 = (DoubleAggregateSummary) group.GetSummary(summaryDescriptor);
                summaryText = string.Format("{0:c}", summary1.Average);

                // or Option 2: Use reflection to get "Average" property of summary
                summaryText = string.Format("{0:c}", group.GetSummaryProperty(summaryDescriptor, "Average"));
                
                // or Option 3: Use reflection to get "Average" property of summary and format it
                summaryText = group.GetFormattedSummaryProperty(summaryDescriptor, "Average", "{0:c}");
            }

            else
            {
                // This is the code you had to use in version 3.0 and earlier (still working but bit more complicate)
                if (summaryDescriptor != null)
                {
                    int indexOfSd1 = table.TableDescriptor.Summaries.IndexOf(summaryDescriptor);

                    // strong typed - you have to cast to DoubleAggregateSummary.

                    DoubleAggregateSummary summary1 = (DoubleAggregateSummary) group.GetSummaries(table)[indexOfSd1];
                    summaryText = string.Format("{0:c}", summary1.Average);
                }
            }
            return summaryText;
        }



		public Class1()
		{
			InitializeComponent();

			bool msdeAvailable = false;
			if (msdeAvailable)
			{
				this.sqlDataAdapter1.Fill(this.dataSet11);
				//this.dataSet11.WriteXml("CustOrders.xml", XmlWriteMode.WriteSchema);
			}
			else
			{
				// Read from a xml file instead. 
                ReadXml(this.dataSet11, @"Common\Data\CustOrders.xml");
			}

			this.engine1 = new Engine();

			// Setup a integrated summary
			sd0 = new SummaryDescriptor();
			
			sd0.MappingName = "Quantity";
			sd0.SummaryType = SummaryType.DoubleAggregate;
			this.engine1.TableDescriptor.Summaries.Add(sd0);

			// Setup custom summaries

			sd1 = new SummaryDescriptor();
			sd1.Name = "QuantityTotal";
			sd1.MappingName = "Quantity";
			sd1.SummaryType = SummaryType.Custom;
			sd1.CreateSummaryMethod = new CreateSummaryDelegate(TotalSummary.CreateSummaryMethod);
			this.engine1.TableDescriptor.Summaries.Add(sd1);
			
			sd2 = new SummaryDescriptor();
			sd2.Name = "QuantityDistinctCount";
			sd2.MappingName = "Quantity";
			sd2.SummaryType = SummaryType.Custom;
			sd2.CreateSummaryMethod = new CreateSummaryDelegate(DistinctInt32CountSummary.CreateSummaryMethod);
			this.engine1.TableDescriptor.Summaries.Add(sd2);

			sd3 = new SummaryDescriptor();
			sd3.Name = "QuantityMedian";
			sd3.MappingName = "Quantity";
			sd3.SummaryType = SummaryType.Custom;
			sd3.CreateSummaryMethod = new CreateSummaryDelegate(StatisticsSummary.CreateSummaryMethod);
			this.engine1.TableDescriptor.Summaries.Add(sd3);

		
			// Setup running totals by displaying the value of a custom counter in an unbound field
			FieldDescriptor unboundField = new FieldDescriptor("QuantityCount", "", false, "");
			unboundField.ReadOnly = false;
			this.engine1.TableDescriptor.UnboundFields.Add(unboundField);
			
			this.engine1.TableDescriptor.QueryValue += new FieldValueEventHandler(unboundField_QueryValue); // Routine that queries for the value
			this.engine1.TableDescriptor.SaveValue += new FieldValueEventHandler(unboundField_SaveValue);

			FieldDescriptor unboundField2 = new FieldDescriptor("QuantityCount2", "", false, "");
			this.engine1.TableDescriptor.UnboundFields.Add(unboundField2);
			
			// Setup custom counter
			this.engine1.Table.QueryCustomCount += new CustomCountEventHandler(Table_QueryCustomCount);
			this.engine1.CurrentRecordContextChange += new CurrentRecordContextChangeEventHandler(engine1_CurrentRecordContextChange);
			this.engine1.Table.QueryVisibleCustomCount += new CustomCountEventHandler(Table_QueryVisibleCustomCount);

			// Assign data source
			this.engine1.SetSourceList(this.dataSet11.Order_Details.DefaultView);

			quantityFieldDescriptor = this.engine1.TableDescriptor.Fields["Quantity"];

			// Add a filter so that we can check out difference between VisibleCustomCount (only records that meet criteria are counted) 
			// and CustomCount (all records are counted)
			this.engine1.TableDescriptor.RecordFilters.Add("[UnitPrice] > 20");
		}

		FieldDescriptor quantityFieldDescriptor; 


		/// <summary>
		/// Query value for unbound field
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void unboundField_QueryValue(object sender, FieldValueEventArgs e)
		{
			if (e.Record is AddNewRecord)
				return;

			if (e.Field.Name == "QuantityCount")
				e.Value = e.Record.GetCustomPosition();
			else
				e.Value = e.Record.GetVisibleCustomPosition();
		}

		/// <summary>
		/// Could write back value here if needed when unbound field is changed by user.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void unboundField_SaveValue(object sender, FieldValueEventArgs e)
		{
			Console.WriteLine(e.Value);
		}



		/// <summary>
		/// Fill in custom counter. This event is called for every record in the table. The CustomCounter
		/// will increase no matter if a record meet filter criteria or not.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Table_QueryCustomCount(object sender, CustomCountEventArgs e)
		{
			if (e.Record is AddNewRecord)
				return;

			object obj = e.Record.GetValue(quantityFieldDescriptor);
			double quantity = Convert.ToDouble(obj);
			e.CustomCount = quantity;
		}

		/// <summary>
		/// Fill in visible custom counter. This event is called for every visible record in the table. The CustomCounter
		/// will increase only for records that meet filter criteria.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Table_QueryVisibleCustomCount(object sender, CustomCountEventArgs e)
		{
			if (e.Record is AddNewRecord)
				return;

			object obj = e.Record.GetValue(quantityFieldDescriptor);
			double quantity = Convert.ToDouble(obj);
			e.CustomCount = quantity;
		}

		/// <summary>
		/// We need to make counters dirty when the record has changed since the custom counters need
		/// to be recalculated for subsequent records. Also, the grid needs to be redrawn.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void engine1_CurrentRecordContextChange(object sender, CurrentRecordContextChangeEventArgs e)
		{
			if (e.Action == CurrentRecordAction.EndEditComplete)
			{
				e.Record.InvalidateCounterBottomUp();
				
			}
		}

		private void InitializeComponent()
		{
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.dataSet11 = new CustomSummary.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details]";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount); SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE (OrderID = @OrderID) AND (ProductID = @ProductID)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Discount", System.Data.SqlDbType.Real, 4, "Discount"));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE [Order Details] SET OrderID = @OrderID, ProductID = @ProductID, UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount WHERE (OrderID = @Original_OrderID) AND (ProductID = @Original_ProductID) AND (Discount = @Original_Discount) AND (Quantity = @Original_Quantity) AND (UnitPrice = @Original_UnitPrice); SELECT OrderID, ProductID, UnitPrice, Quantity, Discount FROM [Order Details] WHERE (OrderID = @OrderID) AND (ProductID = @ProductID)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProductID", System.Data.SqlDbType.Int, 4, "ProductID"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UnitPrice", System.Data.SqlDbType.Money, 8, "UnitPrice"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.SmallInt, 2, "Quantity"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Discount", System.Data.SqlDbType.Real, 4, "Discount"));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Discount", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Discount", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM [Order Details] WHERE (OrderID = @Original_OrderID) AND (ProductID = " +
				"@Original_ProductID) AND (Discount = @Original_Discount) AND (Quantity = @Origin" +
				"al_Quantity) AND (UnitPrice = @Original_UnitPrice)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OrderID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProductID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ProductID", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Discount", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Discount", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.SmallInt, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Quantity", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_UnitPrice", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "UnitPrice", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "Network Address=66.135.59.108,49489;initial catalog=NORTHWIND;password=Sync_samples;persist security info=True;user id=sa;packet size=4096;Pooling=true";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Order Details", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("OrderID", "OrderID"),
																																																					   new System.Data.Common.DataColumnMapping("ProductID", "ProductID"),
																																																					   new System.Data.Common.DataColumnMapping("UnitPrice", "UnitPrice"),
																																																					   new System.Data.Common.DataColumnMapping("Quantity", "Quantity"),
																																																					   new System.Data.Common.DataColumnMapping("Discount", "Discount")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// dataSet11
			// 
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
		}

	}
}
