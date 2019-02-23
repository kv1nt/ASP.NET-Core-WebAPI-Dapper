 UPDATE pd SET pd.Color = @color, pd.Description = @description  
                                          FROM ProductDetails AS pd
                                          WHERE pd.ID = @id